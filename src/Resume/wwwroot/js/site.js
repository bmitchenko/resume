window.addEventListener('load', function () {
    var thumbnails = document.querySelectorAll('.photoswipe-gallery a');

    for (var i = 0; i < thumbnails.length; i++) {
        thumbnails[i].addEventListener('click', onThumbnailClick);
    }
});

function onThumbnailClick(event) {
    var clickedThumbnailElement = closest(event.target, function (el) {
        return (el.tagName && el.tagName.toUpperCase() === 'A');
    });

    if (!clickedThumbnailElement) {
        return;
    }

    var galleryElement = closest(event.target, function (el) {
        return el.classList.contains('photoswipe-gallery');
    });

    if (!galleryElement) {
        return;
    }

    var galleryElements = galleryElement.querySelectorAll('a');

    var index = 0;

    for (var i = 0; i < galleryElements.length; i++) {
        if (galleryElements[i] == clickedThumbnailElement) {
            index = i;
            break;
        }
    }

    showGallery(galleryElements, index);

    event.preventDefault();
    return false;
}

function showGallery(galleryElements, index) {
    var items = [];

    for (var i = 0; i < galleryElements.length; i++) {
        var thumbnailElement = galleryElements[i];

        items.push({
            src: thumbnailElement.getAttribute('href'),
            h: parseInt(thumbnailElement.getAttribute('data-height')),
            title: thumbnailElement.getAttribute('data-description'),
            w: parseInt(thumbnailElement.getAttribute('data-width'))
        });
    }

    var pswpElement = document.querySelectorAll('.pswp')[0];

    var options = {
        index: index
    };

    var gallery = new PhotoSwipe(pswpElement, PhotoSwipeUI_Default, items, options);
    gallery.init();
}

function closest(el, fn) {
    return el && (fn(el) ? el : closest(el.parentNode, fn));
};