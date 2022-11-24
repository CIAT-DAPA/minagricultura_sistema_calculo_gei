// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.addEventListener("DOMContentLoaded", function (event) {

    const showHoverNavbar = (toggleId, navId, bodyId, headerId) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId)
        var width = window.innerWidth;
        console.log(width);
        // Validate that all variables exist

        if (toggle && nav) {
            toggle.addEventListener('mouseover', () => {
                if (nav.classList.contains('show-nav') && (toggleId == "openNav1" || toggleId == "openNav2")) {
                    return
                }
                // show navbar
                nav.classList.toggle('show-nav')

                // add padding to body
                bodypd.classList.toggle('content-pd')
            })

            toggle.addEventListener('mouseout', () => {
                if (nav.classList.contains('show-nav') && (toggleId == "openNav1" || toggleId == "openNav2")) {
                    return
                }
                // show navbar
                nav.classList.toggle('show-nav')

                // add padding to body
                bodypd.classList.toggle('content-pd')
            })
        }

    }

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
                close.classList.toggle('d-none')
                toggle.classList.toggle('d-none')
                nav.classList.toggle('show-nav')
                bodypd.classList.toggle('content-pd')
            })
        }
    }


    showClickNavbar('sidebarCollapse', 'nav-bar', 'content', 'header', 'closeNav');
    if (window.innerWidth >= 768)
        showHoverNavbar('nav-bar', 'nav-bar', 'content', 'header');


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
});