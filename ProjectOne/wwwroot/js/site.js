document.addEventListener("DOMContentLoaded", function () {
    'use strict';

    const currentDate = new Date();
    const yearDate = currentDate.getFullYear();
    document.getElementById('year-date').innerHTML = yearDate;
});