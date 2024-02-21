function logIn(array) {
  let password = array[0].split("").reverse().join("");
  for (let index = 1; index < array.length; index++) {
    if (array[index] === password) {
      console.log(`User ${array[0]} logged in.`);
      return;
    }
    if (index === 4) {
      console.log(`User ${array[0]} blocked!`);
      return;
    }
    console.log(`Incorrect password. Try again.`);
  }
}

logIn(["Acer", "login", "go", "let me in", "recA"]);
logIn(["sunny", "rainy", "cloudy", "sunny", "not sunny"]);
logIn(["momo", "omom"]);
