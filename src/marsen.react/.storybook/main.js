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
  typescript: {
    check: false,
    checkOptions: {},
    reactDocgen: 'react-docgen-typescript',
    reactDocgenTypescriptOptions: {
      shouldExtractLiteralValuesFromEnum: true,
      propFilter: (prop) => (prop.parent ? !/node_modules/.test(prop.parent.fileName) : true),
    },
  },
};
