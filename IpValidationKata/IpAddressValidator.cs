using System;

namespace IpValidationKata
{
    public class IpAddressValidator
    {
        public bool Validate(string ipAddress)
        {
            var segments = ipAddress.Split('.');
            var isValidIp = true;
            if (IsIpInvalid(segments))
            {
                isValidIp= false;
            }
            return isValidIp;
        }

        private bool IsIpInvalid(string[] segments)
        {
            var validNumberOfSegments = segments.Length == 4;
            var lastByte = segments[segments.Length - 1];
            return !validNumberOfSegments || IsInvalidLastByte(lastByte) || ContainsInvalidSegment(segments);
        }

        private bool ContainsInvalidSegment(string[] segments)
        {
            foreach (var segment in segments)
            {
                if (SegmentIsNotNumeric(segment) || NumberInSegmentNotAllowed(segment))
                {
                    return true;
                }
            }
            return false;
        }

        private bool NumberInSegmentNotAllowed(string segment)
        {
            var isNumberOutOfRange = 0 < Int32.Parse(segment) || Int32.Parse(segment) > 255;
            return isNumberOutOfRange;
        }

        private bool SegmentIsNotNumeric(string segment)
        {
            var isNotNumeric = !Int32.TryParse(segment, out var segmentNumeric);
            return isNotNumeric;
        }

        private bool IsInvalidLastByte(string lastByte)
        {
            return lastByte == "0" || lastByte == "255";
        }
    }
}
