function solve(input) {
  const [flights, newStatus, statusPrint] = input;

  const flightsIdList = flights.reduce((acc, flight) => {
    const [number, ...destinationNameParts] = flight.split(" ");
    const destination = destinationNameParts.join(" ");
    const status = "Ready to fly";
    acc.push({
      id: number,
      destination,
      status,
    });
    return acc;
  }, []);

  newStatus.forEach((elements) => {
    const [curentId, ...newS] = elements.split(" ");
    const flight = flightsIdList.find((obj) => obj.id === curentId);
    if (flight) {
      flight.status = newS.join(" ");
    }
  });

   flightsIdList.forEach(element => {
    if(element.status === statusPrint[0]){
        console.log(`{ Destination: '${element.destination}', Status: '${element.status}' }`)
    }
   });
}

solve([
  [
    "WN269 Delaware",
    "FL2269 Oregon",
    "WN498 Las Vegas",
    "WN3145 Ohio",
    "WN612 Alabama",
    "WN4010 New York",
    "WN1173 California",
    "DL2120 Texas",
    "KL5744 Illinois",
    "WN678 Pennsylvania",
  ],
  [
    "DL2120 Cancelled",
    "WN612 Cancelled",
    "WN1173 Cancelled",
    "SK430 Cancelled",
  ],
  ["Cancelled"],
]);
