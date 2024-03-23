function solve(input) {

    function parseGarageInfo(garageInfoString) {
  
      let [key, valuesString] = garageInfoString.split(" - ");
      let values = valuesString.split(", ");
  
      let garageObj = values.reduce((object, prop) => {
  
        let [k, v] = prop.split(": ");
        object[k] = v;
  
        return object;
      }, {});
  
      return { key, garageObj };
    }
  
    function printGarage(garageNumber, cars) {
  
      console.log(`Garage № ${garageNumber}`);
  
      cars.forEach((car) => {
  
        let carDetails = Object.entries(car).map(
          ([key, value]) => `${key} - ${value}`
        );
  
        console.log(`--- ${carDetails.join(", ")}`);
  
      });
    }
  
    const garagesList = input.reduce((acc, current) => {
  
      let { key, garageObj } = parseGarageInfo(current);
      if (!acc[key]) {
        acc[key] = [];
      }
  
      acc[key].push(garageObj);
  
      return acc;
      
    }, {});
  
    for (const [garageNumber, cars] of Object.entries(garagesList)) {
      printGarage(garageNumber, cars);
    }
  }
  
  solve([
    "1 - color: blue, fuel type: diesel",
    "1 - color: red, manufacture: Audi",
    "2 - fuel type: petrol",
    "4 - color: dark blue, fuel type: diesel, manufacture: Fiat",
  ]);
  