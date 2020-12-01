module.exports = {
  stories: [
    '../src/components/*.stories.jsx',
    '../src/components/Task/*.stories.jsx',
    '../src/components/TicTacToe/*.stories.jsx'],
  addons: [    
    '@storybook/preset-create-react-app',
    '@storybook/addon-essentials/',
    '@storybook/addon-actions',
    '@storybook/addon-links',    
  ],
};
