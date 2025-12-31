document.addEventListener('DOMContentLoaded', () => {

    function showToast(message) {
        let toast = document.getElementById('toast');

        if (!toast) {
            toast = document.createElement('div');
            toast.id = 'toast';
            toast.style.position = 'fixed';
            toast.style.right = '20px';
            toast.style.bottom = '20px';
            toast.style.padding = '12px 16px';
            toast.style.background = '#222';
            toast.style.color = '#fff';
            toast.style.borderRadius = '10px';
            toast.style.opacity = '0';
            toast.style.transform = 'translateY(10px)';
            toast.style.transition = '.25s';
            toast.style.zIndex = '9999';
            toast.style.pointerEvents = 'none';
            document.body.appendChild(toast);
        }

        toast.textContent = message;
        toast.style.opacity = '1';
        toast.style.transform = 'translateY(0)';

        clearTimeout(window.__toastTimer);
        window.__toastTimer = setTimeout(() => {
            toast.style.opacity = '0';
            toast.style.transform = 'translateY(10px)';
        }, 2000);
    }

    document.addEventListener('click', async (e) => {
        const btn = e.target.closest('.add-to-cart');
        if (!btn) return;

        e.preventDefault();

        const id = btn.dataset.id;

        try {
            const res = await fetch(`/Basket/Add?id=${id}`, { method: 'POST' });

            const text = await res.text();

            if (!res.ok) throw new Error("Server error. Status: " + res.status);

            const data = JSON.parse(text);

            const basketCountEl = document.querySelector('.basket-count');
            if (basketCountEl) basketCountEl.innerText = data.totalCount;

            const oldText = btn.innerText;
            btn.innerText = "Added ✓";
            btn.style.color = "green";

            setTimeout(() => {
                btn.innerText = "Add to cart";
                btn.style.color = "";
            }, 1000);

            btn.disabled = true;

            setTimeout(() => {
                btn.innerText = oldText;
                btn.disabled = false;
            }, 1000);

            const productName = data?.item?.name ?? "Product";
            showToast(`${productName} added to basket ✅`);

        } catch (err) {
            console.error(err);
            showToast(err.message);
        }
    });

});
