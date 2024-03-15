function solve(input) {
  let adresBook = input.reduce((acc, curent) => {
    const [name, adres] = curent.split(":");
    acc[name] = adres;
    return acc;
  }, {});

  let sortedName = Object.keys(adresBook).sort();

  sortedName.forEach((x) => console.log(`${x} -> ${adresBook[x]}`));
}

solve([
  "Tim:Doe Crossing",
  "Bill:Nelson Place",
  "Peter:Carlyle Ave",
  "Bill:Ornery Rd",
]);

slove([
  "Bob:Huxley Rd",
  "John:Milwaukee Crossing",
  "Peter:Fordem Ave",
  "Bob:Redwing Ave",
  "George:Mesta Crossing",
  "Ted:Gateway Way",
  "Bill:Gateway Way",
  "John:Grover Rd",
  "Peter:Huxley Rd",
  "Jeff:Gateway Way",
  "Jeff:Huxley Rd",
]);
