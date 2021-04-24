jQueryAjaxDelete = (form, message) => {
    if (confirm(message)) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    location.reload();
                },
                error: function (err) {
                    console.log(err);
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}
