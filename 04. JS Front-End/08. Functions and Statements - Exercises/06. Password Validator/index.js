function passValidator(pass) {
  let flag = true;
  let regexLettersAndDigits = /^[a-zA-Z0-9]+$/;
  let regexTwoOrMoreDigits = /^(?:.*\d){2}/;

  if (pass.length < 6 || pass.length > 10) {
    console.log("Password must be between 6 and 10 characters");
    flag = false;
  }

  if (!regexLettersAndDigits.test(pass)) {
    console.log("Password must consist only of letters and digits");
    flag = false;
  }

  if (!regexTwoOrMoreDigits.test(pass)) {
    console.log("Password must have at least 2 digits");
    flag = false;
  }

  if (flag) {
    console.log("Password is valid");
  }
}

passValidator("logIn");
passValidator("MyPass123");
passValidator("Pa$s$s");
