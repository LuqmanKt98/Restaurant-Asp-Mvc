// Enhanced Authentication Page JavaScript

// Password Toggle Functionality
function initPasswordToggle() {
    const passwordToggles = document.querySelectorAll('.password-toggle');
    
    passwordToggles.forEach(toggle => {
        toggle.addEventListener('click', function(e) {
            e.preventDefault();
            const input = this.parentElement.querySelector('.form-control');
            const icon = this.querySelector('i');
            
            if (input && input.type === 'password') {
                input.type = 'text';
                icon.classList.remove('fa-eye');
                icon.classList.add('fa-eye-slash');
                this.setAttribute('aria-label', 'Hide password');
            } else if (input) {
                input.type = 'password';
                icon.classList.remove('fa-eye-slash');
                icon.classList.add('fa-eye');
                this.setAttribute('aria-label', 'Show password');
            }
        });
    });
}

// Form Loading State
function initFormLoading() {
    const loginForm = document.getElementById('loginForm');
    const submitBtn = document.querySelector('.btn-auth');
    
    if (loginForm && submitBtn) {
        loginForm.addEventListener('submit', function(e) {
            // Add loading state
            submitBtn.classList.add('loading');
            submitBtn.disabled = true;
            
            // Remove loading state after 3 seconds if form hasn't submitted
            setTimeout(() => {
                if (submitBtn.classList.contains('loading')) {
                    submitBtn.classList.remove('loading');
                    submitBtn.disabled = false;
                }
            }, 3000);
        });
    }
}

// Enhanced Form Validation
function initFormValidation() {
    const inputs = document.querySelectorAll('.form-control-modern');
    
    inputs.forEach(input => {
        // Real-time validation feedback
        input.addEventListener('blur', function() {
            validateField(this);
        });
        
        input.addEventListener('input', function() {
            // Clear error state on input
            this.classList.remove('is-invalid');
            const errorElement = this.parentElement.parentElement.querySelector('.field-error');
            if (errorElement) {
                errorElement.style.display = 'none';
            }
        });
    });
}

function validateField(field) {
    const value = field.value.trim();
    const fieldName = field.getAttribute('name');
    let isValid = true;
    let errorMessage = '';
    
    // Email validation
    if (fieldName === 'Email') {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!value) {
            isValid = false;
            errorMessage = 'Email is required';
        } else if (!emailRegex.test(value)) {
            isValid = false;
            errorMessage = 'Please enter a valid email address';
        }
    }
    
    // Password validation
    if (fieldName === 'Password') {
        if (!value) {
            isValid = false;
            errorMessage = 'Password is required';
        } else if (value.length < 6) {
            isValid = false;
            errorMessage = 'Password must be at least 6 characters';
        }
    }
    
    // Update field state
    if (!isValid) {
        field.classList.add('is-invalid');
        showFieldError(field, errorMessage);
    } else {
        field.classList.remove('is-invalid');
        hideFieldError(field);
    }
    
    return isValid;
}

function showFieldError(field, message) {
    const container = field.parentElement.parentElement;
    let errorElement = container.querySelector('.field-error');
    
    if (!errorElement) {
        errorElement = document.createElement('span');
        errorElement.className = 'field-error';
        container.appendChild(errorElement);
    }
    
    errorElement.textContent = message;
    errorElement.style.display = 'block';
}

function hideFieldError(field) {
    const container = field.parentElement.parentElement;
    const errorElement = container.querySelector('.field-error');
    
    if (errorElement) {
        errorElement.style.display = 'none';
    }
}

// Smooth Animations
function initAnimations() {
    // Animate elements on page load
    const animatedElements = document.querySelectorAll('.auth-card, .benefit-item, .brand-badge');
    
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, {
        threshold: 0.1
    });
    
    animatedElements.forEach(element => {
        element.style.opacity = '0';
        element.style.transform = 'translateY(20px)';
        element.style.transition = 'opacity 0.6s ease, transform 0.6s ease';
        observer.observe(element);
    });
}

// Floating Label Effect
function initFloatingLabels() {
    const inputs = document.querySelectorAll('.form-control-modern');
    
    inputs.forEach(input => {
        const wrapper = input.parentElement;
        const label = wrapper.parentElement.querySelector('.form-label-modern');
        
        if (label) {
            // Check if input has value on load
            if (input.value) {
                label.classList.add('active');
            }
            
            input.addEventListener('focus', () => {
                label.classList.add('active');
            });
            
            input.addEventListener('blur', () => {
                if (!input.value) {
                    label.classList.remove('active');
                }
            });
        }
    });
}

// Remember Me Functionality
function initRememberMe() {
    const rememberCheckbox = document.getElementById('RememberMe');
    const emailInput = document.querySelector('input[name="Email"]');
    
    if (rememberCheckbox && emailInput) {
        // Load saved email on page load
        const savedEmail = localStorage.getItem('rememberedEmail');
        if (savedEmail) {
            emailInput.value = savedEmail;
            rememberCheckbox.checked = true;
        }
        
        // Save email when form is submitted
        const form = document.getElementById('loginForm');
        if (form) {
            form.addEventListener('submit', () => {
                if (rememberCheckbox.checked) {
                    localStorage.setItem('rememberedEmail', emailInput.value);
                } else {
                    localStorage.removeItem('rememberedEmail');
                }
            });
        }
    }
}

// Keyboard Navigation Enhancement
function initKeyboardNavigation() {
    const inputs = document.querySelectorAll('.form-control-modern');
    
    inputs.forEach((input, index) => {
        input.addEventListener('keydown', (e) => {
            if (e.key === 'Enter') {
                e.preventDefault();
                
                // Move to next input or submit form
                if (index < inputs.length - 1) {
                    inputs[index + 1].focus();
                } else {
                    const submitBtn = document.querySelector('.btn-auth');
                    if (submitBtn) {
                        submitBtn.click();
                    }
                }
            }
        });
    });
}

// Initialize all functionality when DOM is loaded
document.addEventListener('DOMContentLoaded', function() {
    initPasswordToggle();
    initFormLoading();
    initFormValidation();
    initAnimations();
    initFloatingLabels();
    initRememberMe();
    initKeyboardNavigation();
    
    // Add CSS for invalid state
    const style = document.createElement('style');
    style.textContent = `
        .form-control-modern.is-invalid {
            border-color: var(--danger-500) !important;
            box-shadow: 0 0 0 3px rgba(239, 68, 68, 0.1) !important;
        }
        
        .form-label-modern.active {
            transform: translateY(-8px) scale(0.85);
            color: var(--primary-600);
        }
        
        .form-label-modern {
            transition: all 0.2s ease;
            transform-origin: left top;
        }
    `;
    document.head.appendChild(style);
});

// Export functions for external use
window.AuthJS = {
    validateField,
    showFieldError,
    hideFieldError
};