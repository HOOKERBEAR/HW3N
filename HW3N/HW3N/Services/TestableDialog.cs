using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HW3N.Services
{
    public static class TestableDialog
    {
        public static Func<IPageDialogService, string, string, string, string[], Task<string>> TestableDisplayActionSheetAsync =
                    (dialogSvc, title, cancelButton, destroyButton, buttons) => dialogSvc.DisplayActionSheetAsync(title, cancelButton, destroyButton, buttons);
        public static Func<IPageDialogService, string, IActionSheetButton[], Task> TestableDisplayActionSheetTwoAsync =
                    (dialogSvc, title, buttons) => dialogSvc.DisplayActionSheetAsync(title, buttons);
        public static Func<IPageDialogService, string, string, string, string, Task<bool>> TestableDisplayAlertAsync =
            (dialogSvc, title, message, accept, cancel) => dialogSvc.DisplayAlertAsync(title, message, accept, cancel);
        public static Func<IPageDialogService, string, string, string, Task> TestableDisplayAlertTwoAsync =
            (dialogSvc, title, message, cancel) => dialogSvc.DisplayAlertAsync(title, message, cancel);
    }

}
