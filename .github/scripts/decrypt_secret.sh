#!/bin/sh

# Decrypt the file
mkdir secrets
# --batch to prevent interactive command
# --yes to assume "yes" for questions
# gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" \
# --output secrets/firebase-adminsdk.json D:/Projects/Tracker/firebase-adminsdk.json.gpg

gpg --quiet --batch --yes --output secrets/firebase-adminsdk.json --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" firebase-adminsdk.json.gpg