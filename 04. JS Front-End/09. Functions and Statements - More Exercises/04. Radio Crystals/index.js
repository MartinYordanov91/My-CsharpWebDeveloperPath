function shapingCrystals(params) {
  const [requiredSize, ...thickness] = params;

  for (let index = 0; index < thickness.length; index++) {
    let element = thickness[index];
    let countOperations = 0;
    console.log(`Processing chunk ${element} microns`);

    while (element !== requiredSize) {
      // cut
      if (element * 0.25 >= requiredSize - 1) {
        while (element * 0.25 >= requiredSize - 1) {
          element *= 0.25;
          countOperations++;
        }

        element = Math.floor(element);
        console.log(`Cut x${countOperations}`);
        console.log(`Transporting and washing`);
        countOperations = 0;
      }

      //lap
      if (element * 0.8 >= requiredSize - 1) {
        while (element * 0.8 >= requiredSize - 1) {
          element *= 0.8;
          countOperations++;
        }

        element = Math.floor(element);
        console.log(`Lap x${countOperations}`);
        console.log(`Transporting and washing`);
        countOperations = 0;
      }

      //Grind
      if (element - 20 >= requiredSize - 1) {
        while (element - 20 >= requiredSize - 1) {
          element -= 20;
          countOperations++;
        }

        element = Math.floor(element);
        console.log(`Grind x${countOperations}`);
        console.log(`Transporting and washing`);
        countOperations = 0;
      }

      //Etch
      if (element - 2 >= requiredSize - 1) {
        while (element - 2 >= requiredSize - 1) {
          element -= 2;
          countOperations++;
        }

        element = Math.floor(element);
        console.log(`Etch x${countOperations}`);
        console.log(`Transporting and washing`);
        countOperations = 0;
      }

      //X-ray
      if (element + 1 === requiredSize) {
        element += 1;
        console.log(`X-ray x1`);
      }
    }
    console.log(`Finished crystal ${element} microns`);
  }
}

shapingCrystals([1375, 50000]);
shapingCrystals([1000, 4000, 8100])