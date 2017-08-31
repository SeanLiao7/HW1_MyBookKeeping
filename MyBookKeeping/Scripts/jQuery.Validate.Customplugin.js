﻿$.validator.addMethod("positivenumber", function (value, element, param) {
    return value > 0 && value % 1 === 0 && value <= parseInt(param);
});
$.validator.unobtrusive.adapters.addSingleVal("positivenumber", "input");