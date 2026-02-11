$(document).ready(function() {

    async function getKanyeQuote(){
        try {
            const response = await fetch("https://api.kanye.rest/")
            if (!response.ok) {
                throw new Error("Error with HTTP")
            }
            const data = await response.json();
            return data.quote;
        } catch(error){
            console.error("Couldn't fetch quote")
        }
    }

    async function getStrangerThingsQuote(){
        try {
            const response = await fetch("https://strangerthingsquotes.shadowdev.xyz/api/quotes")
            if (!response.ok) {
                throw new Error("Error with HTTP")
            }
            const data = await response.json();
            return data[0].quote;
        } catch(error){
            console.error("Couldn't fetch quote")
        }
    }


     function chooseNumber(choice){
        if (choice < 0.5){
            getKanyeQuote().then(function (quote) {
                $("#quote").text("''" + quote + "''");
            });
        }
        if (choice >= 0.5){
            getStrangerThingsQuote().then(function (quote){
                $("#quote").text("''" + quote + "''");
            });
        }
    }

    function updateScore(score){
        $("#score").html("Score:" + score)
        $("#alternating-img").attr("src", correctImg)
    }

    let choice= Math.random();
    chooseNumber(choice);

    const correctImg = "https://free-images.com/md/2c07/checkmark_bold_brush_green.jpg";
    const wrongImg = "https://free-images.com/md/7b89/wrong_way_sign_road.jpg"


    var score=0;
    $("#kanye-quote").on("click", function (){
        if (choice < 0.5){
            score += 1;
            updateScore(score)
            
        }
        else{
            $("#alternating-img").attr("src", wrongImg)
        }

        choice=Math.random();
        chooseNumber(choice);
    });

    $("#strangerthings-quote").on("click", function (){
        if (choice >= 0.5){
            score += 1;
            updateScore(score)
        }
        else{
            $("#alternating-img").attr("src", wrongImg)
        }

        choice=Math.random();
        chooseNumber(choice);
    });
});