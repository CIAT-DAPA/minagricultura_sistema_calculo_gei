var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl)
})

document.addEventListener("DOMContentLoaded", function (event) {

    const navbar = document.getElementById('nav-bar');
    const bodyStorage = document.getElementById('content');
    const closeStorage = document.getElementById('closeNav'); 
    const openStorage = document.getElementById('btn-open');
    let shouldAnimate = true;
    // Guardar estado en el navegador local
    function saveNavbarState() {
        localStorage.setItem('navbarState', navbar.classList.contains('show-nav') ? 'expanded' : 'collapsed');
    }

    // Leer estado desde el navegador local y aplicarlo
    function applyNavbarState() {
        const navbarState = localStorage.getItem('navbarState');
        if (navbarState === 'collapsed') {
            navbar.classList.remove('show-nav');
            bodyStorage.classList.remove('content-pd')
            closeStorage.classList.add('d-none')
            openStorage.classList.remove('d-none')
            
        } else {
            
            navbar.classList.add('show-nav');
            bodyStorage.classList.add('content-pd')
            closeStorage.classList.remove('d-none')
            openStorage.classList.add('d-none')
        }
    }

    function animateNavbar() {
        if (shouldAnimate) {
            navbar.classList.toggle('nav-animation');
            bodyStorage.classList.toggle('content-animation')
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
                popoverList.map(e => e._isEnabled = false)
                close.classList.toggle('d-none')
                toggle.classList.toggle('d-none')
                nav.classList.toggle('show-nav')
                bodypd.classList.toggle('content-pd')
                saveNavbarState();
                animateNavbar();
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
                saveNavbarState();
                animateNavbar();
            })
        }
    }


    showClickNavbar('btn-open', 'nav-bar', 'content', 'header', 'closeNav');

    // Aplicar el estado guardado cada vez que se cargue una vista
    applyNavbarState();
    shouldAnimate = false;
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