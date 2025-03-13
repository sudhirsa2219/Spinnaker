
FROM node:22-alpine

# Set working directory
WORKDIR /app

COPY package.json package-lock.json ./
RUN npm install

RUN npm i -g serve

COPY . .

# Pass environment variable at build time
ARG VITE_MICRO_SERVICE_URL
ENV VITE_MICRO_SERVICE_URL=${VITE_MICRO_SERVICE_URL}

RUN npm run build

EXPOSE 3000

CMD ["serve", "-s", "dist"]
