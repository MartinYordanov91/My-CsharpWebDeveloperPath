function carCleaner(procedures) {
  let carPercentClean = 0;

  const services = {
    soap: (n) => (n += 10),
    water: (n) => (n *= 1.2),
    "vacuum cleaner": (n) => (n *= 1.25),
    mud: (n) => (n *= 0.9),
  };

  for (let index = 0; index < procedures.length; index++) {
    carPercentClean = services[procedures[index]](carPercentClean);
  }

  console.log(`The car is ${carPercentClean.toFixed(2)}% clean.`);
}

carCleaner(["soap", "soap", "vacuum cleaner", "mud", "soap", "water"]);
carCleaner(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);
