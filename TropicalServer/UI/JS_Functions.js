function validateForm() {

    var x = document.forms["myForm"]["userid"].value;
    var y = document.forms["myForm"]["userpassword"].value;

    if (x == "" || y == "" || x == null || y == "") {
        alert("UserID or password cannot be null.");
        return false;
    }


}