
const { createProxyMiddleware } = require('http-proxy-middleware');
const backendUrl = process.env.REACT_APP_SERVER_URL || 'http://localhost:9080';

module.exports = function (app) {

    app.use(
        '/api',
        createProxyMiddleware({
            target: backendUrl,
            changeOrigin: true,
            secure: false
        })
    );
};