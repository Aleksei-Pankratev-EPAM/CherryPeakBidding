# pull official base image
FROM node:14.2.0-alpine as builder
WORKDIR /app
COPY . .
RUN yarn install
RUN yarn run build

FROM mhart/alpine-node:14.2.0
RUN yarn global add serve
WORKDIR /app
COPY --from=builder /app/build .
CMD ["serve", "-p", "80", "-s", "."]