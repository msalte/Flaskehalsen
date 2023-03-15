import { FC } from "react";

export const metadata = {
  title: "Flaskehalsen",
  description: "Ratingsystem for gode drikkevarer",
};

type RootLayoutProps = {
  children: React.ReactNode;
};

const RootLayout: FC<RootLayoutProps> = ({ children }) => {
  return (
    <html lang="en">
      <body>
        <div>Dette innholdet endres ikke ved navigering</div>
        {children}
      </body>
    </html>
  );
};

export default RootLayout;
