
export function getScrollLeft(element) {
    let r = element.scrollLeft;
    if (element.parentElement) {
        r += getScrollLeft(element.parentElement);
    }
    return r;
}

export function getScrollTop(element) {
    let r = element.scrollTop;
    if (element.parentElement) {
        r += getScrollTop(element.parentElement);
    }
    return r;
}

export function getOffsetLeft(element) {
    let r = element.offsetLeft;
    if (element.offsetParent) {
        r += getOffsetLeft(element.offsetParent);
    }
    return r;
}

export function getOffsetTop(element) {
    let r = element.offsetTop;
    if (element.offsetParent) {
        r += getOffsetTop(element.offsetParent);
    }
    return r;
}

export function getLeft(element) {
    let ox = getOffsetLeft(element);
    let sx = getScrollLeft(element);
    return ox - sx;
}

export function getTop(element) {
    let oy = getOffsetTop(element);
    let sy = getScrollTop(element);
    return oy - sy;
}
