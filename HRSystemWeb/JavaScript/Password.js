
function ValidateForm(upassID)
{

var sizechar = 8;//length for password

//check if passsword is filled out
if ((upassID.value==null)||(upassID.value==""))
{
        alert("Please enter your password");
        upassID.focus();
        return false;
}
if (upassID.length < sizechar) 
{
    alert('Your enter password greater than 8 character');
    upassID.focus();
    return false;
}
var upass_string = upassID.value;



var alphaCount = 0;
var numCount = 0;
var num_valid="0123456789";

for (var i=0; i<sizechar; i++)
 {
        if(num_valid.indexOf(upass_string.charAt(i)) < 0) 
        {
                numCount++
        }
}
if(numCount==upass_string.length)
{
    alert('Your password contains only characters. Please enter an alphanumeric value like -alpha1-');
    upassID.focus();
    return false;
}

var alph_valid="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~-_"

for (var i=0; i<sizechar; i++) {
        if (alph_valid.indexOf(upass_string.charAt(i)) < 0) 
        {
                alphaCount++
        }
}
        alert("Alpha Counter: " + alphaCount);
        if(alphaCount==upass_string.length)
        {
            alert('Your password contains only numbers. Please enter an alphanumeric value like -alpha1-');
            upassID.focus();
            return false;
        }
return true;
}
