function solve(input) {
  let employees = input.reduce((acc, curent) => {
    let personalNum = curent.length;
    acc[curent] = personalNum;
    return acc;
  }, {});

  for (const [key, value] of Object.entries(employees)) {
    console.log(`Name: ${key} -- Personal Number: ${value}`);
  }
}

solve([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);

slove(["Samuel Jackson", "Will Smith", "Bruce Willis", "Tom Holland"]);
