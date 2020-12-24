module.exports = {
  stories: [
    '../src/components/Task/*.stories.tsx',    
    '../src/components/TicTacToe/*.stories.tsx',
    '../src/components/*.stories.tsx'],
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
