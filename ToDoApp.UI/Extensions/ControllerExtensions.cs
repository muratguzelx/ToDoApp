using Microsoft.AspNetCore.Mvc;
using ToDoApp.Common.ResponseObjects;

namespace ToDoApp.UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRediResultToAction<T>(this Controller controller, IResponse<T> response,
            string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.validationErrors)
                {
                    controller.ModelState.AddModelError(error.ErrorMessage, error.PropertyName);
                }

                return controller.View(response.Data);
            }

            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            return controller.View(response.Data);
        }

        public static IActionResult ResponseRediResultToAction(this Controller controller, IResponse response,
            string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }

            return controller.RedirectToAction(actionName);
        }

    }
}
