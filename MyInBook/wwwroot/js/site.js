document.addEventListener('DOMContentLoaded', () => {
    const elements = document.querySelectorAll('.fade-in');
    elements.forEach(el => {
        el.style.opacity = 0;
        setTimeout(() => {
            el.style.transition = 'opacity 1s ease-in-out';
            el.style.opacity = 1;
        }, 100);
    });
});
