function solve(input) {
  const numberOfBaristaTeam = Number(input.shift());
  let BaristaTeam = {};

  for (let index = 0; index < numberOfBaristaTeam; index++) {
    let [name, shift, drinks] = input.shift().split(" ");

    if (!BaristaTeam[name]) {
      BaristaTeam[name] = {};
    }

    BaristaTeam[name].shift = shift;
    BaristaTeam[name].drinks = drinks.split(",");
  }

  let curentRow;

  while ((curentRow = input.shift()) !== "Closed") {
    const comand = curentRow.split(" / ")[0];
    const baristaName = curentRow.split(" / ")[1];

    if (comand === "Prepare") {
      const baristaShift = curentRow.split(" / ")[2];
      const coffeWonted = curentRow.split(" / ")[3];

      if (BaristaTeam[baristaName]) {
        if (
          BaristaTeam[baristaName].shift !== baristaShift ||
          !BaristaTeam[baristaName].drinks.includes(coffeWonted)
        ) {
          console.log(
            `${baristaName} is not available to prepare a ${coffeWonted}.`
          );
          continue;
        }

        console.log(`${baristaName} has prepared a ${coffeWonted} for you!`);
      }
    } else if (comand === "Change Shift") {
      const baristaShift = curentRow.split(" / ")[2];

      if (BaristaTeam[baristaName]) {
        BaristaTeam[baristaName].shift = baristaShift;
        console.log(`${baristaName} has updated his shift to: ${baristaShift}`);
      }
    } else if (comand === "Learn") {
      const baristaNewCoffe = curentRow.split(" / ")[2];

      if (BaristaTeam[baristaName]) {
        if (BaristaTeam[baristaName].drinks.includes(baristaNewCoffe)) {
          console.log(`${baristaName} knows how to make ${baristaNewCoffe}.`);
        } else {
          BaristaTeam[baristaName].drinks.push(baristaNewCoffe);
          console.log(
            `${baristaName} has learned a new coffee type: ${baristaNewCoffe}.`
          );
        }
      }
    }
  }

  for (const baristaName in BaristaTeam) {
    let barista = BaristaTeam[baristaName];
    console.log(`Barista: ${baristaName}, Shift: ${barista.shift}, Drinks: ${barista.drinks.join(", ")}`);
  }
}

solve([
  "3",
  "Alice day Espresso,Cappuccino",
  "Bob night Latte,Mocha",
  "Carol day Americano,Mocha",
  "Prepare / Alice / day / Espresso",
  "Change Shift / Bob / night",
  "Learn / Carol / Latte",
  "Learn / Bob / Latte",
  "Prepare / Bob / night / Latte",
  "Closed",
]);
