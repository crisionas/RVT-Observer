jQuery(document).ready(function () {
    jQuery('#vmap').vectorMap({
        map: 'moldova_md',
        backgroundColor: null,
        color: '#d2d4d5',
        hoverColor: '#006ed6',
        enableZoom: false,
        showTooltip: true,
 

        onRegionClick: function (event, code, region) {
            switch (code) {
                case code:
                    window.location.replace("/Map/RM/" + code);
            }
        }
    });
});
