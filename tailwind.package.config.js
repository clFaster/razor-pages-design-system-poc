/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/RazorTailwind.DesignSystem/**/*.{cshtml,cs}",
    "./src/**/Pages/**/*.{cshtml,cshtml.cs}",
  ],
  theme: {
    extend: {
      colors: {
        brand: {
          50: "#f1f7fe",
          100: "#dceafe",
          200: "#b9dafc",
          500: "#2d8cf0",
          600: "#1f74cb",
          700: "#195da3",
        },
      },
      fontFamily: {
        sans: ["Plus Jakarta Sans", "Segoe UI", "sans-serif"],
        display: ["Space Grotesk", "Plus Jakarta Sans", "sans-serif"],
      },
      boxShadow: {
        soft: "0 18px 45px -24px rgb(15 23 42 / 0.45)",
      },
    },
  },
  plugins: [],
};
