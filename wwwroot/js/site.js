// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Quantity control functions
function increaseQuantity(button, maxStock) {
    const input = button.parentElement.querySelector('.quantity-input');
    let currentValue = parseInt(input.value);
    if (currentValue < maxStock) {
        input.value = currentValue + 1;
    }
}

function decreaseQuantity(button) {
    const input = button.parentElement.querySelector('.quantity-input');
    let currentValue = parseInt(input.value);
    if (currentValue > 1) {
        input.value = currentValue - 1;
    }
}

// Auto-dismiss alerts
document.addEventListener('DOMContentLoaded', function() {
    // Auto-dismiss alerts after 5 seconds
    const alerts = document.querySelectorAll('.auto-dismiss');
    alerts.forEach(function(alert) {
        setTimeout(function() {
            const bsAlert = new bootstrap.Alert(alert);
            bsAlert.close();
        }, 5000);
    });
});

// Food Details Modal functionality
function showFoodDetails(foodId) {
    const modal = new bootstrap.Modal(document.getElementById('foodDetailsModal'));
    const loadingElement = document.getElementById('foodDetailsLoading');
    const contentElement = document.getElementById('foodDetailsContent');
    
    // Show loading state
    loadingElement.style.display = 'flex';
    contentElement.innerHTML = loadingElement.outerHTML;
    
    // Show modal
    modal.show();
    
    // Fetch food details
    fetch(`/api/food/${foodId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            // Hide loading
            loadingElement.style.display = 'none';
            
            // Populate modal content
            contentElement.innerHTML = generateFoodDetailsHTML(data);
        })
        .catch(error => {
            console.error('Error fetching food details:', error);
            contentElement.innerHTML = `
                <div class="text-center p-5">
                    <i class="bi bi-exclamation-triangle text-warning" style="font-size: 3rem;"></i>
                    <h4 class="mt-3">Error Loading Details</h4>
                    <p class="text-muted">Unable to load food details. Please try again later.</p>
                </div>
            `;
        });
}

function generateFoodDetailsHTML(food) {
    const ingredientsHTML = food.ingredients && food.ingredients.length > 0 
        ? food.ingredients.map(ingredient => `<span class="ingredient-tag">${ingredient.name}</span>`).join('')
        : '<span class="text-muted">No ingredients listed</span>';
    
    const nutritionHTML = food.nutrition ? `
        <div class="nutrition-grid">
            <div class="nutrition-item">
                <span class="nutrition-value">${food.nutrition.calories || 'N/A'}</span>
                <div class="nutrition-label">Calories</div>
            </div>
            <div class="nutrition-item">
                <span class="nutrition-value">${food.nutrition.protein || 'N/A'}g</span>
                <div class="nutrition-label">Protein</div>
            </div>
            <div class="nutrition-item">
                <span class="nutrition-value">${food.nutrition.carbs || 'N/A'}g</span>
                <div class="nutrition-label">Carbs</div>
            </div>
            <div class="nutrition-item">
                <span class="nutrition-value">${food.nutrition.fat || 'N/A'}g</span>
                <div class="nutrition-label">Fat</div>
            </div>
            <div class="nutrition-item">
                <span class="nutrition-value">${food.nutrition.fiber || 'N/A'}g</span>
                <div class="nutrition-label">Fiber</div>
            </div>
            <div class="nutrition-item">
                <span class="nutrition-value">${food.nutrition.sodium || 'N/A'}mg</span>
                <div class="nutrition-label">Sodium</div>
            </div>
        </div>
    ` : '<p class="text-muted">Nutritional information not available</p>';
    
    const preparationHTML = food.preparationSteps && food.preparationSteps.length > 0 
        ? food.preparationSteps.map((step, index) => `
            <div class="preparation-step">
                <div class="step-number">${index + 1}</div>
                <div class="step-content">${step}</div>
            </div>
        `).join('')
        : '<p class="text-muted">Preparation steps not available</p>';
    
    return `
        <div class="food-details-container">
            <div class="row">
                <div class="col-lg-5">
                    <div class="food-image-container">
                        <img src="${food.imageUrl && food.imageUrl.startsWith('http') ? food.imageUrl : '/images/' + (food.imageUrl || 'default-food.jpg')}" alt="${food.name}" class="img-fluid food-image">
                    </div>
                </div>
                <div class="col-lg-7">
                    <div class="food-info-section">
                        <h1 class="food-title">${food.name}</h1>
                        <div class="food-price">€${parseFloat(food.price).toFixed(2)}</div>
                        <p class="food-description">${food.description || 'No description available'}</p>
                        
                        <div class="d-flex align-items-center mb-3">
                            <div class="badge ${food.stock > 0 ? 'bg-success' : 'bg-danger'} me-3">
                                <i class="bi ${food.stock > 0 ? 'bi-check-circle' : 'bi-x-circle'} me-1"></i>
                                ${food.stock > 0 ? 'In Stock' : 'Out of Stock'}
                            </div>
                            <div class="text-muted">
                                <i class="bi bi-box me-1"></i>
                                ${food.stock} available
                            </div>
                        </div>
                        
                        ${food.stock > 0 ? `
                            <div class="d-flex gap-2 mb-4">
                                <form action="/Order/AddItem" method="post" style="display: inline;">
                                    <input type="hidden" name="FoodId" value="${food.id}" />
                                    <input type="hidden" name="Quantity" value="1" />
                                    <button type="submit" class="btn btn-primary btn-lg">
                                        <i class="bi bi-bag-plus me-2"></i>Order Now
                                    </button>
                                </form>
                            </div>
                        ` : ''}
                    </div>
                </div>
            </div>
            
            <div class="row mt-4">
                <div class="col-lg-4">
                    <div class="info-card">
                        <h5><i class="bi bi-heart-pulse"></i>Nutritional Facts</h5>
                        ${nutritionHTML}
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="info-card">
                        <h5><i class="bi bi-list-ul"></i>Ingredients</h5>
                        <div class="ingredients-list">
                            ${ingredientsHTML}
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="info-card">
                        <h5><i class="bi bi-clock"></i>Preparation</h5>
                        <div class="preparation-steps">
                            ${preparationHTML}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    `;
}

// Removed addToWishlist function as per user request

// Write your JavaScript code.
