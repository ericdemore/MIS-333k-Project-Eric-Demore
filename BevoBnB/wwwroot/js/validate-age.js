document.addEventListener('DOMContentLoaded', function () {
    const dobInput = document.querySelector('[name="DOB"]');
    const errorContainer = document.createElement('div');
    errorContainer.classList.add('text-danger', 'mb-3');

    dobInput.parentNode.insertBefore(errorContainer, dobInput.nextSibling);

    dobInput.addEventListener('input', function () {
        const dobValue = new Date(dobInput.value);
        if (isNaN(dobValue.getTime())) {
            errorContainer.textContent = 'Please enter a valid date.';
            return;
        }

        const today = new Date();
        const age = today.getFullYear() - dobValue.getFullYear();
        const isBirthdayPassed = today.getMonth() > dobValue.getMonth() ||
            (today.getMonth() === dobValue.getMonth() && today.getDate() >= dobValue.getDate());

        if (age < 18 || (age === 18 && !isBirthdayPassed)) {
            errorContainer.textContent = 'You must be at least 18 years old to sign up.';
        } else {
            errorContainer.textContent = '';
        }
    });
});
