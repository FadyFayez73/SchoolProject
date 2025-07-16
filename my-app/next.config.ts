import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  async rewrites() {
    return [
      {
        source: "/api/:slug*", // يلتقط students, departments, subjects... إلخ
        destination: "https://schoolproject-production-784b.up.railway.app/api/:slug*",
      },
    ];
  },
};

export default nextConfig;
