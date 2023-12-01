﻿self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open('app-cache').then((cache) => {
            return Promise.all([
                '/',
                '/ajax/libs/font-awesome/6.4.2/css/all.min.css',
                '/lib/*'
            ].map(url => {
                return fetch(url)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Failed to fetch');
                        }
                        return cache.put(url, response);
                    })
                    .catch(error => {
                        console.error(`Failed to cache ${url}:`, error);
                    });
            }));
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            return response || fetch(event.request);
        })
    );
});
