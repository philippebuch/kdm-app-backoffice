module.exports = {
    devServer: {
      proxy: {
        '^/api': {
          target: 'https://localhost:6000'
        },
      }
    }
  }