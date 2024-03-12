function personInfo(firstName, lastName, age) {
  const obj = {
    firstName,
    lastName,
    age: Number(age),
  };

  return obj;
}

console.log(personInfo("Marto" , "Yordanov" , "30"))