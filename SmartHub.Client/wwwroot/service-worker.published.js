// Questo file viene generato automaticamente da Blazor durante la pubblicazione
self.importScripts('./service-worker-assets.js');

self.addEventListener('install', event => event.waitUntil(onInstall(event)));
self.addEventListener('activate', event => event.waitUntil(onActivate(event)));
self.addEventListener('fetch', event => event.respondWith(onFetch(event)));

async function onInstall(event) {
    console.info('Service worker: Install');

    // Carica tutti gli asset definiti nel manifest generato da Blazor
    const assetsRequests = self.assetsManifest.assets
        .map(asset => new Request(asset.url, { integrity: asset.hash, cache: 'no-cache' }));

    const cache = await caches.open('offline-cache');
    await cache.addAll(assetsRequests);
}

async function onActivate(event) {
    console.info('Service worker: Activate');
    // Qui andrebbe la logica per eliminare le vecchie cache se necessario
}

async function onFetch(event) {
    let cachedResponse = null;
    if (event.request.method === 'GET') {
        // Cerca prima nella cache
        const shouldServeFromCache = event.request.mode === 'navigate';
        const cache = await caches.open('offline-cache');
        cachedResponse = await cache.match(event.request);
    }

    return cachedResponse || fetch(event.request);
}