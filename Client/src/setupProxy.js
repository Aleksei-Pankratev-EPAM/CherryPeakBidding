
const { createProxyMiddleware } = require('http-proxy-middleware');
const backendUrl = process.env.REACT_APP_SERVER_URL;

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