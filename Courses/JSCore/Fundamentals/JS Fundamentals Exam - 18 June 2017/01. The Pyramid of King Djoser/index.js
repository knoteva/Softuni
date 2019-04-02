function solve(widthLength, step){
    //console.log(typeof width);
    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let gold = 0;
    let count = 0;
    let currentSize = 0;
    let reduceSize = 0;

    for(let i = widthLength; i > 0; i-=2){
        //console.log(i);
        if(i - 2 <= 0){
            gold = i * i;
        } else {
            currentSize = i * i;
            reduceSize = (i - 2) * (i - 2);
            stone += reduceSize;
            if((count+1) % 5 == 0 && count > 0){
                lapis += currentSize - reduceSize;
            } else {
                marble += currentSize - reduceSize;
            }
        }       
        count++;
    }
    stone = Math.ceil(stone * step);
    marble = Math.ceil(marble * step);
    lapis = Math.ceil(lapis * step);
    gold = Math.ceil(gold * step);
    let height = Math.floor(count * step);
    console.log(`Stone required: ${stone}`);
    console.log(`Marble required: ${marble}`);
    console.log(`Lapis Lazuli required: ${lapis}`);
    console.log(`Gold required: ${gold}`);
    console.log(`Final pyramid height: ${height}`);
}
//solve('23','0.5');