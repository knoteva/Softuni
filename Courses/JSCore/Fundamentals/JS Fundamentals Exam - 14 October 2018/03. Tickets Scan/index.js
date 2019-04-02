function solve(str, key) {
    let regexName = /([\s][A-Z][A-Za-z]*-[A-Z][A-Za-z]*\s)|([\s][A-Z][A-Za-z]*-[A-Z][A-Za-z]*\.-[A-Z][A-Za-z]*)/g;
    let regexAirport = /[\s][A-Z]{3}\/[A-Z]{3}[\s]/g;
    let regexFlifght = /[\s][A-Z]{1,3}[0-9]{1,5}[\s]/g;
    let regexCompany = /-\s[A-Z][A-Za-z]*\*[A-Z][A-Za-z]*\s/g;

    let name = str.match(regexName)[0];
    //name = name.replace(/\./g,' ');
    name = name.replace(/\-/g,' ');
    name = name.replace(/  +/g, ' ').trim();
    let airport = str.match(regexAirport);
    let fromAirport= airport[0].split('/')[0].trim();
    let toAirport= airport[0].split('/')[1].trim();
    let flightNumber = str.match(regexFlifght)[0].trim();
    let company = str.match(regexCompany)[0].trim();
    company = company.replace(/\*/g,' ');
    company = company.replace(/\- /g,'');
    //console.log(flightNumber)

    if(key == 'name'){
        console.log(`Mr/Ms, ${name}, have a nice flight!`)
    }
    if(key == 'flight'){
        console.log(`Your flight number ${flightNumber} is from ${fromAirport} to ${toAirport}.`)
    }
    if(key == 'company'){
        console.log(`Have a nice flight with ${company}.`)
    } 
    if(key == 'all'){
        console.log(`Mr/Ms, ${name}, your flight number ${flightNumber} is from ${fromAirport} to ${toAirport}. Have a nice flight with ${company}.`)
    }
      

}

//solve('ahah Second-Testov )*))&&ba SOF/VAR ela** FB973 - Bulgaria*Air -opFB900 pa-SOF/VAr//_- T12G12 STD08:45  STA09:35 Kate-Note-Mama. ', 'all');
//solve(' TEST-T.-TESTOV   SOF/VIE OS806 - Austrian*Airlines T24G55 STD11:15 STA11:50 flight ', 'all');