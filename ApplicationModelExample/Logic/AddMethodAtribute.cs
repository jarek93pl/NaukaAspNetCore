using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationModelExample.Logic
{
    public class AddMethodAtribute : Attribute, IActionModelConvention
    {
        public string AddActionName { get; set; }
        public void Apply(ActionModel action)
        {
            action.Controller.Actions.Add(new ActionModel(action) { ActionName = AddActionName });
        }
    }
}
