function onlineShop(selector) {
    let form = `<div id="header">Online Shop Inventory</div>
    <div class="block">
        <label class="field">Product details:</label>
        <br>
        <input placeholder="Enter product" class="custom-select">
        <input class="input1" id="price" type="number" min="1" max="999999" value="1"><label class="text">BGN</label>
        <input class="input1" id="quantity" type="number" min="1" value="1"><label class="text">Qty.</label>
        <button id="submit" class="button" disabled>Submit</button>
        <br><br>
        <label class="field">Inventory:</label>
        <br>
        <ul class="display">
        </ul>
        <br>
        <label class="field">Capacity:</label><input id="capacity" readonly>
        <label class="field">(maximum capacity is 150 items.)</label>
        <br>
        <label class="field">Price:</label><input id="sum" readonly>
        <label class="field">BGN</label>
    </div>`;
    $(selector).html(form);
    let sum = 0;
    let capacity = 0;
     $('.custom-select').keyup(function(){
            if($(this).val().length !=0){
                $('#submit').attr('disabled', false);            
            }else{
                $('#submit').attr('disabled',true);
            }
        })
        $("#submit").click(function(){
            let row = $('<li>').text(`Product: ${$('.custom-select').val()} Price: ${$('#price').val()} Quantity: ${$('#quantity').val()}`)
            $('.display').append(row)
            $('.title').val('');
            $('.content').val('');
            sum += +$('#price').val();
            $('#sum').val(sum)
            capacity += +$('#quantity').val();
            if(capacity < 150){
                $('#capacity').val(capacity)
            } else {
                $('#capacity').val('full');
                $("#capacity").addClass("fullCapacity");
                $('#submit').attr('disabled',true);
                $('#price').attr('disabled',true);
                $('#quantity').attr('disabled',true);
                $('.custom-select').attr('disabled',true);
            }

            $('#price').val(1)
            $('#quantity').val(1)
            $('.custom-select').val('')
            // if($(this).val().length !=0){
            //     $('#submit').attr('disabled', false);            
            // }else{
            //     $('#submit').attr('disabled',true);
            // }
        });   
}
