function solve(params) {
  const countAstrunauts = params.shift();
  const astrunauts = {};

  for (let index = 0; index < countAstrunauts; index++) {
    const [name, oxygen, energy] = params.shift().split(" ");
    if (!astrunauts[name]) {
      astrunauts[name] = {
        name,
        oxygen: Number(oxygen),
        energy: Number(energy),
      };
    }
  }

  let command;
  while ((command = params.shift()) !== "End") {
    const [cCom, name, cost] = command.split(" - ");

    switch (cCom) {
      case "Explore":
        if (astrunauts[name].energy - Number(cost) >= 0) {
          astrunauts[name].energy -= Number(cost);
          console.log(
            `${name} has successfully explored a new area and now has ${astrunauts[name].energy} energy!`
          );
        } else {
          console.log(`${name} does not have enough energy to explore!`);
        }
        break;
      case "Refuel":
        let refuelAmount;

        if (astrunauts[name].energy + Number(cost) > 200) {
          refuelAmount = 200 - astrunauts[name].energy;
        } else {
          refuelAmount = Number(cost);
        }
        astrunauts[name].energy += refuelAmount;
        console.log(`${name} refueled their energy by ${refuelAmount}!`);
        break;
      case "Breathe":
        let reOxygen;

        if (astrunauts[name].oxygen + Number(cost) > 100) {
          reOxygen = 100 - astrunauts[name].oxygen;
        } else {
          reOxygen = Number(cost);
        }
        astrunauts[name].oxygen += reOxygen;
        console.log(`${name} took a breath and recovered ${reOxygen} oxygen!`);
        break;
    }
  }
  Object.values(astrunauts).forEach((austrunaut) => {
    console.log(
      `Astronaut: ${austrunaut.name}, Oxygen: ${austrunaut.oxygen}, Energy: ${austrunaut.energy}`
    );
  });
}

solve([
  "3",
  "John 50 120",
  "Kate 80 180",
  "Rob 70 150",
  "Explore - John - 50",
  "Refuel - Kate - 30",
  "Breathe - Rob - 20",
  "End",
]);
solve([
  "4",
  "Alice 60 100",
  "Bob 40 80",
  "Charlie 70 150",
  "Dave 80 180",
  "Explore - Bob - 60",
  "Refuel - Alice - 30",
  "Breathe - Charlie - 50",
  "Refuel - Dave - 40",
  "Explore - Bob - 40",
  "Breathe - Charlie - 30",
  "Explore - Alice - 40",
  "End",
]);
