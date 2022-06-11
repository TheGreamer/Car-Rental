using CarRental.Business.Abstract;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;
using System;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class TeamMembersController : BaseController<TeamMember, ITeamMemberService>
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMembersController(ITeamMemberService teamMemberService) : base(teamMemberService) => _teamMemberService = teamMemberService;

        [HttpPost]
        public override ActionResult Create(TeamMember entity, HttpPostedFileBase Image) => DataEntry(entity, Image, DataEntryState.Added);

        [HttpPost]
        public override ActionResult Edit(TeamMember entity, HttpPostedFileBase Image) => DataEntry(entity, Image, DataEntryState.Modified);

        [NonAction]
        private ActionResult DataEntry(TeamMember entity, HttpPostedFileBase image, DataEntryState dataEntryState)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    entity.Image = Utility.SaveFile(image, Server.MapPath("~/Content/img/team/"));

                    switch (dataEntryState)
                    {
                        case DataEntryState.Added:
                        {
                            _teamMemberService.Add(entity);
                            return RedirectToAction("Index");
                        }
                        case DataEntryState.Modified:
                        {
                            _teamMemberService.Update(entity);
                            return Redirect($"~/Admin/TeamMembers/Edit/{entity.Id}");
                        }
                    }
                }
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "Resim yüklerken bir hata oluştu.";
                    ViewBag.GoBackLink = $"/TeamMembers/{(dataEntryState == DataEntryState.Added ? "Create" : "Edit")}";
                    return View("Error");
                }
            }

            return View(entity);
        }
    }

    public enum DataEntryState { Added, Modified }
}