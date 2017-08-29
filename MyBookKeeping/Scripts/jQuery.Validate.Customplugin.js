$.validator.addMethod("positivenumber", function (value, element, param) {
    if (value === false) {
        return true;
    }
    return value > 0 && value <= param && value % 1 === 0;
});
$.validator.unobtrusive.adapters.addSingleVal("positivenumber", "input");