const app = () => {
    const clap = document.getElementById('clap');
    const clapIcon = document.getElementById('clap--icon');
    const clapCount = document.getElementById('clap--count');
    const clapTotalCount = document.getElementById('clap--count-total');
    let initialNumberOfClaps;
    const btnDimension = 80;
    const tlDuration = 300;
    let numberOfClaps = 0;
    let clapsSent = 0;
    let clapHold;

    const triangleBurst = new mojs.Burst({
        parent: clap,
        radius: { 50: 95 },
        count: 5,
        angle: 30,
        children: {
            shape: 'polygon',
            radius: { 6: 0 },
            scale: 1,
            stroke: 'rgba(211,84,0 ,0.5)',
            strokeWidth: 2,
            angle: 210,
            delay: 30,
            speed: 0.2,
            easing: mojs.easing.bezier(0.1, 1, 0.3, 1),
            duration: tlDuration
        }
    });
    const circleBurst = new mojs.Burst({
        parent: clap,
        radius: { 50: 75 },
        angle: 25,
        duration: tlDuration,
        children: {
            shape: 'circle',
            fill: 'rgba(149,165,166 ,0.5)',
            delay: 30,
            speed: 0.2,
            radius: { 3: 0 },
            easing: mojs.easing.bezier(0.1, 1, 0.3, 1),
        }
    });
    const countAnimation = new mojs.Html({
        el: '#clap--count',
        isShowStart: false,
        isShowEnd: true,
        y: { 0: -30 },
        opacity: { 0: 1 },
        duration: tlDuration
    }).then({
        opacity: { 1: 0 },
        y: -80,
        delay: tlDuration / 2
    });
    const countTotalAnimation = new mojs.Html({
        el: '#clap--count-total',
        isShowStart: false,
        isShowEnd: true,
        opacity: { 1: 1 },
        delay: 3 * (tlDuration) / 2,
        duration: tlDuration,
        y: { 0: -3 }
    });
    const scaleButton = new mojs.Html({
        el: '#clap',
        duration: tlDuration,
        scale: { 1.3: 1 },
        easing: mojs.easing.out
    });
    clap.style.transform = "scale(1, 1)";/*Bug1 fix*/

    const animationTimeline = new mojs.Timeline();
    animationTimeline.add([
        triangleBurst,
        circleBurst,
        countAnimation,
        countTotalAnimation,
        scaleButton
    ]);

    getPostClaps();

    clap.addEventListener('click', function () {
        repeatClapping();
    });

    clap.addEventListener('mousedown', function () {
        clapHold = setInterval(function () {
            repeatClapping();
        }, 400);
    });

    clap.addEventListener('mouseup', function () {
        clearInterval(clapHold);
    });


    function repeatClapping() {
        updateNumberOfClaps();
        postClaps();
        animationTimeline.replay();
        clapIcon.classList.add('checked');
    }

    function updateNumberOfClaps() {
        numberOfClaps < 50 ? numberOfClaps++ : null;
        clapCount.innerHTML = "+" + numberOfClaps;
        clapTotalCount.innerHTML = initialNumberOfClaps + numberOfClaps;
    }


    async function getPostClaps() {
        const postId = document.querySelector('[data-postId]').textContent;
        const url = `/${postId}/claps`;
        fetch(url)
            .then(response => response.json())
            .then(clapResponseHandler)
            .catch(console.log);
    }

    function clapResponseHandler(res) {
        res = JSON.parse(res);
        if (initialNumberOfClaps === undefined) initialNumberOfClaps = res.Claps;
        clapTotalCount.innerHTML = initialNumberOfClaps - numberOfClaps;
    }

    let postingClaps;
    const postClaps = () => {
        console.log("moving");
        clearTimeout(postingClaps);
        let clapsToSend = numberOfClaps - clapsSent;
        postingClaps = setTimeout(
            function () {
                console.log("about to");

                if (clapsToSend > 0) {
                    console.log(clapsToSend, " sent");
                    fetchPostClaps(clapsToSend);
                    console.log(clapsToSend, " sent");
                }
            },
            1000);
    };

    const fetchPostClaps = (numberOfClapsToSend) => {
        const messageHeaders = new Headers({
            'Content-Type': 'application/json'
        });
        const postId = document.querySelector('[data-postId]').textContent;
        const url = `/clap`;
        var data = { PostId: `${postId}`, ClapNumber: `${numberOfClapsToSend}` }
        fetch(url, {
            method: 'POST',
            body: JSON.stringify({ PostId: `${postId}`, ClapNumber: `${numberOfClapsToSend}` }),
            headers: messageHeaders
        }).then(response => response.json());
        //.then(clapResponseHandler)
        //.catch(console.log);
        console.log(url);
        clapsSent += numberOfClapsToSend;
    };

}

$(document).ready(app());

/*====== TODO ==========
1. Bug fix. The button shouldn't 
scale up before being clicked (fixed)
2. Shadow should NOT fire hover 
animation in succession. 
Some sort of delay is delay. (Not that important)
3. Hover animation should be 
absent upon click (Not that important)
4. Handle onpress event on the button (Implemetaation is Buggy ATM)
5. Dynamically change burst angle 
everytime button is clicked 
=========================*/