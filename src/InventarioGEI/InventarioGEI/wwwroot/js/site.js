var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl)
})

document.addEventListener("DOMContentLoaded", function (event) {

    //const showHoverNavbar = (toggleId, navId, bodyId, headerId) => {
    //    const toggle = document.getElementById(toggleId),
    //        nav = document.getElementById(navId),
    //        bodypd = document.getElementById(bodyId),
    //        headerpd = document.getElementById(headerId)
    //    var width = window.innerWidth;
    //    console.log(width);
    //    // Validate that all variables exist

    //    if (toggle && nav) {
    //        toggle.addEventListener('mouseover', () => {
    //            if (nav.classList.contains('show-nav') && (toggleId == "openNav1" || toggleId == "openNav2")) {
    //                return
    //            }
    //            // show navbar
    //            nav.classList.toggle('show-nav')

    //            // add padding to body
    //            bodypd.classList.toggle('content-pd')
    //        })

    //        toggle.addEventListener('mouseout', () => {
    //            if (nav.classList.contains('show-nav') && (toggleId == "openNav1" || toggleId == "openNav2")) {
    //                return
    //            }
    //            // show navbar
    //            nav.classList.toggle('show-nav')

    //            // add padding to body
    //            bodypd.classList.toggle('content-pd')
    //        })
    //    }

    //}

    //const showHoverNavbar = (toggleId, navId, bodyId, headerId) => {
    //    const toggle = document.getElementById(toggleId),
    //        nav = document.getElementById(navId),
    //        bodypd = document.getElementById(bodyId),
    //        headerpd = document.getElementById(headerId),
    //        close = document.getElementById('closeNav')
    //    var width = window.innerWidth;
    //    console.log(width);
    //    // Validate that all variables exist

    //    if (toggle && nav) {
    //        toggle.addEventListener('mouseover', () => {
    //            if (nav.classList.contains('show-nav') && (toggleId == "openNav1" || toggleId == "openNav2") || !close.classList.contains('d-none')) {
    //                return
    //            }
    //            bodypd.classList.toggle('d-none')
    //        })

    //        toggle.addEventListener('mouseout', () => {
    //            if (nav.classList.contains('show-nav') && (toggleId == "openNav1" || toggleId == "openNav2") || !close.classList.contains('d-none')) {
    //                return
    //            }

    //            bodypd.classList.toggle('d-none')
    //        })
    //    }

    //}

    const showClickNavbar = (toggleId, navId, bodyId, headerId, closeId) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId),
            close = document.getElementById(closeId)

        // Validate that all variables exist
        if (toggle && nav && close) {
            toggle.addEventListener('click', () => {
                if (nav.classList.contains('show-nav') && (toggleId == "openNav1" || toggleId == "openNav2")) {
                    return
                }
                // show navbar
                popoverList.map(e => e._isEnabled = false)
                close.classList.toggle('d-none')
                toggle.classList.toggle('d-none')
                nav.classList.toggle('show-nav')
                bodypd.classList.toggle('content-pd')
            })

            close.addEventListener('click', () => {
                if (nav.classList.contains('show-nav') && (toggleId == "openNav1" || toggleId == "openNav2")) {
                    return
                }
                // show navbar
                popoverList.map(e => e._isEnabled = true)
                close.classList.toggle('d-none')
                toggle.classList.toggle('d-none')
                nav.classList.toggle('show-nav')
                bodypd.classList.toggle('content-pd')
            })
        }
    }


    showClickNavbar('btn-open', 'nav-bar', 'content', 'header', 'closeNav');
    //showHoverNavbar('nav-bar', 'nav-bar', 'btn-open', 'header');
   // showClickNavbar('btn-open', 'nav-bar', 'content', 'header', 'closeNav');
    //if (window.innerWidth >= 768)
    //    showHoverNavbar('nav-bar', 'nav-bar', 'content', 'header');


    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link')

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'))
            this.classList.add('active')
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink))

    // Your code to run since DOM is loaded and ready

    $('#detail').click(function () {
        $('.tableHidden').removeClass("d-none");
        $(this).addClass("d-none");
        $('#detailHide').removeClass("d-none");
    });
    $('#detailHide').click(function () {
        $('.tableHidden').addClass("d-none");
        $(this).addClass("d-none");
        $('#detail').removeClass("d-none");
    });
});