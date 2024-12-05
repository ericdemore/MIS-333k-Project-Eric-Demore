document.addEventListener("DOMContentLoaded", function () {
    // Get input elements for pricing and discount
    const weekdayPriceInput = document.querySelector("#WeekdayPricing");
    const weekendPriceInput = document.querySelector("#WeekendPricing");
    const discountRateInput = document.querySelector("#DiscountRate");

    // Create a discount preview element
    const discountPreview = document.createElement("div");
    discountPreview.style.color = "green";
    discountPreview.style.marginTop = "10px";
    discountRateInput.parentNode.appendChild(discountPreview);

    // Function to calculate discounted prices
    function calculateDiscountedPrices() {
        const weekdayPrice = parseFloat(weekdayPriceInput.value) || 0;
        const weekendPrice = parseFloat(weekendPriceInput.value) || 0;
        const discountRate = parseFloat(discountRateInput.value) || 0;

        if (discountRate > 0 && discountRate <= 1) {
            const discountedWeekday = weekdayPrice - weekdayPrice * discountRate;
            const discountedWeekend = weekendPrice - weekendPrice * discountRate;

            discountPreview.innerHTML = `
                <strong>Discounted Prices:</strong> <br>
                Weekday: $${discountedWeekday.toFixed(2)} <br>
                Weekend: $${discountedWeekend.toFixed(2)}
            `;
        } else if (discountRate > 1 || discountRate < 0) {
            discountPreview.innerHTML = `<span style="color:red;">Discount rate must be between 0 and 1.</span>`;
        } else {
            discountPreview.innerHTML = "";
        }
    }

    // Attach event listeners to inputs
    [weekdayPriceInput, weekendPriceInput, discountRateInput].forEach(input => {
        input.addEventListener("input", calculateDiscountedPrices);
    });
});
