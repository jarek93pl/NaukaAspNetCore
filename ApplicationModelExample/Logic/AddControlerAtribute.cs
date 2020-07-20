using ApplicationModelExample.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApplicationModelExample.Logic
{
    public class AddControlerAtribute : Attribute, IControllerModelConvention
    {
        public string Prefix { get; set; }
        public string SeconName { get; set; }
        public void Apply(ControllerModel controller)
        {
            ControllerModel con;
            string newName = "";
            if (Prefix != null)
            {
                newName = Prefix + controller.ControllerName;
            }
            else
            {
                newName = SeconName;
            }
            controller.Application.Controllers.Add(con = new ControllerModel(typeof(HomeController).GetTypeInfo(), new object[0]) { ControllerName = newName });
            foreach (var item in controller.Actions)
            {
                con.Actions.Add(new ActionModel(item) { Controller = con });
            }
        }
    }
}
