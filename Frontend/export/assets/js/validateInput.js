function validateInputOnlyNumbers(event) {
    if (event.charCode < 48 || event.charCode > 57) {
        event.preventDefault();
    }
}