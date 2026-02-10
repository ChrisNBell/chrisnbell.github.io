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

    function getStrangerThingsQuote(){

    }

     function chooseNumber(choice){
        if (choice < 0.5){
            $("#quote").text(getKanyeQuote())
        }
        else {
            $("#quote").text("Stranger Things Quote")
        }
    }

    function updateScore(score){
        $("#score").html("Score:" + score)
    }

    let choice= Math.random();
    chooseNumber(choice);


    var score=0;
    $("#kanye-quote").on("click", function (){
        if (choice < 0.5){
            score += 1;
            updateScore(score)
        }

        choice=Math.random();
        chooseNumber(choice);
    });

    $("#strangerthings-quote").on("click", function (){
        if (choice >= 0.5){
            score += 1;
            updateScore(score)
        }

        choice=Math.random();
        chooseNumber(choice);

    });
});